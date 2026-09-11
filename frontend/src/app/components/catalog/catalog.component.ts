import { AfterViewInit, ChangeDetectorRef, Component, ElementRef, ViewChild } from '@angular/core';
import { ProductComponent } from './product.component';
import { ProductFiltersComponent } from './product-filters.component';
import { ProductsApiService } from '../../services/apiservices/products.apiservice';
import { take } from 'rxjs';
import { FilterModel } from '../../models/filter.model';
import { LoadingService } from '../../services/loading.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { HtmlElementsHelper } from '../../helpers/html-elements.helper';
import { ProductFullDto } from '../../dtos/product-full.dto';

/** Компонент каталога продуктов */
@Component({
    selector: 'catalog-component',
    templateUrl: './catalog.component.html',
    imports: [
        ProductComponent,
        ProductFiltersComponent
    ],
    providers: [
        ProductsApiService,
        LoadingService
    ]
})
export class CatalogComponent implements AfterViewInit {
    /** Список товаров. */
    public products: ProductFullDto[] = [];

    /** Словарь "Идентификатор товара"-"Список url картинок". */
    public productIdImageUrlMap: Map<number, string[]> = new Map<number, string[]>();

    /** Компонент с фильтрами. */
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

    /** Загрузить товары с сервера учитывая фильтры. */
    protected loadProductsFromServer(filter: FilterModel): void {
        if (this.loadingService.getIsLoadingValue()) {
            return;
        }
        this.loadingService.startLoading();
        this.productsApiService.getProducts(filter).pipe(take(1)).subscribe(products => {
            this.products = products;
            this.loadingService.endLoading();
            // При проверке с delay каталог не отрисовывался без изменений на странице в
            // браузере, поэтому использовал detectChanges()
            this.cdr.detectChanges();
        });
    }
}
