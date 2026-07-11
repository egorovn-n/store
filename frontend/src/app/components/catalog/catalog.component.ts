import { AfterViewInit, ChangeDetectorRef, Component, ElementRef, ViewChild } from '@angular/core';
import { ProductComponent } from './product.component';
import { ProductFiltersComponent } from './product-filters.component';
import { ProductAndNumberDto } from '../../dtos/product-and-number.dto';
import { ProductIdAndNumberDto } from '../../dtos/product-id-and-number.dto';
import { ProductWithImgSrc } from '../../dtos/product-with-img-src.dto';
import { ProductsApiService } from '../../services/apiservices/products.apiservice';
import { delay, take } from 'rxjs';
import { FilterModel } from '../../models/filter.model';
import { AsyncPipe } from '@angular/common';
import { LoadingService } from '../../services/loading.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { HtmlElementsHelper } from '../../helpers/html-elements.helper';

/** Компонент каталога продуктов */
@Component({
    selector: 'catalog-component',
    templateUrl: './catalog.component.html',
    imports: [
        ProductComponent,
        ProductFiltersComponent,
        AsyncPipe
    ],
    providers: [
        ProductsApiService,
        LoadingService
    ]
})
export class CatalogComponent implements AfterViewInit {
    /** Список продуктов с количеством в корзине */
    public itemsWithNumbers: ProductAndNumberDto<ProductWithImgSrc>[] = [];

    /** Компонент с фильтрами */
    @ViewChild(ProductFiltersComponent, { static: false })
    private filtersComponent: ProductFiltersComponent | undefined;

    @ViewChild('catalog', { static: false })
    private catalog: ElementRef | undefined;

    constructor(protected loadingService: LoadingService,
                private productsApiService: ProductsApiService,
                private cdr: ChangeDetectorRef) {
        loadingService.isLoading$.pipe(takeUntilDestroyed()).subscribe(isLoading => {
            HtmlElementsHelper.setInputDisabledAttribute(isLoading, this.catalog);
            HtmlElementsHelper.setButtonDisabledAttribute(isLoading, this.catalog);
        })
    }

    public ngAfterViewInit() {
        // Таймаут для предотвращения ошибки ExpressionChangedAfterItHasBeenCheckedError
        setTimeout(() => {
            if (this.filtersComponent) {
                this.filtersComponent.initFilters();
            }
        });
    }

    /** Коллбэк для изменения количества продуктов в корзине */
    public onProductNumberChange(productIdAndNumberDto: ProductIdAndNumberDto) {
        if (this.loadingService.getIsLoadingValue()) {
            return;
        }
        let productIndex = this.itemsWithNumbers.findIndex(
            (item) => item.product.id === productIdAndNumberDto.productId
        );
        if (productIndex < 0) {
            return;
        }
        this.itemsWithNumbers[productIndex].productsNumber = productIdAndNumberDto.productNumber;
    }

    /** Загрузить продукты с сервера учитывая фильтры */
    protected loadProductsFromServer(filter: FilterModel): void {
        console.log('filter')
        if (this.loadingService.getIsLoadingValue()) {
            return;
        }
        this.loadingService.startLoading();
        this.productsApiService.getProducts(filter).pipe(take(1)).subscribe(products => {
            this.itemsWithNumbers = products;
            this.loadingService.endLoading();
            // При проверке с delay каталог не отрисовывался без изменений на странице в
            // браузере, поэтому использовал detectChanges()
            this.cdr.detectChanges();
        });
    }
}
