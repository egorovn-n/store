import { Component, OnInit } from '@angular/core';
import { ProductComponent } from './product.component';
import { ProductFiltersComponent } from './product-filters.component';
import { ProductAndNumberDto } from '../../dtos/product-and-number.dto';
import { ProductIdAndNumberDto } from '../../dtos/product-id-and-number.dto';
import { ProductWithImgSrc } from '../../dtos/product-with-img-src.dto';
import { ProductsApiService } from '../../services/apiservices/products.apiservice';
import { take } from 'rxjs';
import { FilterModel } from '../../models/filter.model';
import { ActivatedRoute, Params } from '@angular/router';
import { FilterHelper } from '../../helpers/filter.helper';

@Component({
    selector: 'catalog-component',
    templateUrl: './catalog.component.html',
    imports: [
        ProductComponent,
        ProductFiltersComponent
    ],
    providers: [
        ProductsApiService
    ]
})
export class CatalogComponent implements OnInit {
    public itemsWithNumbers: ProductAndNumberDto<ProductWithImgSrc>[] = [];
    public filter: FilterModel = new FilterModel();

    constructor(private productsApiService: ProductsApiService,
                activatedRoute: ActivatedRoute) {
        activatedRoute.queryParams.pipe(take(1)).subscribe((params: Params) => {
            FilterHelper.fillFilterFromParams(this.filter, params);
        });
    }

    public ngOnInit() {
        this.productsApiService.getProducts(this.filter).pipe(take(1)).subscribe(products => {
            this.itemsWithNumbers = products;
        });
    }

    public onProductNumberChange(productIdAndNumberDto: ProductIdAndNumberDto) {
        let productIndex = this.itemsWithNumbers.findIndex(
            (item) => item.product.id === productIdAndNumberDto.productId
        );
        if (productIndex < 0) {
            return;
        }
        this.itemsWithNumbers[productIndex].productsNumber = productIdAndNumberDto.productNumber;
    }
}
