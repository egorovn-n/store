import { Component } from '@angular/core';
import { ProductComponent } from './product.component';
import { ProductFiltersComponent } from './product-filters.component';
import { ProductAndNumberDto } from '../../dtos/product-and-number.dto';
import { ProductIdAndNumberDto } from '../../dtos/product-id-and-number.dto';
import { ProductWithImgSrc } from '../../dtos/product-with-img-src.dto';

@Component({
    selector: 'catalog-component',
    templateUrl: './catalog.component.html',
    imports: [
        ProductComponent,
        ProductFiltersComponent
    ]
})
export class CatalogComponent {
    public itemsWithNumbers: ProductAndNumberDto<ProductWithImgSrc>[] = [];

    constructor() {
        this.setFakeItems();
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

    private setFakeItems(): void {
        const products: ProductWithImgSrc[] = [
            new ProductWithImgSrc(0, 'картошка',10, 'favicon.ico'),
            new ProductWithImgSrc(1, 'огурец',20, 'favicon.ico'),
            new ProductWithImgSrc(2, 'колбаса',50, 'favicon.ico'),
            new ProductWithImgSrc(3, 'квас',15, 'favicon.ico'),
            new ProductWithImgSrc(4, 'яйца',20, 'favicon.ico'),
            new ProductWithImgSrc(5, 'майонез',10, 'favicon.ico'),
            new ProductWithImgSrc(6, 'морковь',8, 'favicon.ico'),
            new ProductWithImgSrc(7, 'лук',7, 'favicon.ico'),
            new ProductWithImgSrc(8, 'свёкла',11, 'favicon.ico'),
            new ProductWithImgSrc(9, 'чеснок',10, 'favicon.ico'),
        ]

        this.itemsWithNumbers = products.map((item) => new ProductAndNumberDto(item, Math.round(Math.random())));
    }
}
