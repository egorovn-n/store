import { Component } from '@angular/core';
import { Product } from '../../models/product.model';
import { ProductComponent } from './product.component';
import { ProductFiltersComponent } from './product-filters.component';
import { ProductAndNumberDto } from '../../dtos/product-and-number.dto';
import { ProductIdAndNumberDto } from '../../dtos/product-id-and-number.dto';

@Component({
    selector: 'catalog-component',
    templateUrl: './catalog.component.html',
    imports: [
        ProductComponent,
        ProductFiltersComponent
    ]
})
export class CatalogComponent {
    public itemsWithNumbers: ProductAndNumberDto[] = [];

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
        const products: Product[] = [
            new Product(0, 'картошка',10),
            new Product(1, 'огурец',20),
            new Product(2, 'колбаса',50),
            new Product(3, 'квас',15),
            new Product(4, 'яйца',20),
            new Product(5, 'майонез',10),
            new Product(6, 'морковь',8),
            new Product(7, 'лук',7),
            new Product(8, 'свёкла',11),
            new Product(9, 'чеснок',10),
        ]

        this.itemsWithNumbers = products.map((item) => new ProductAndNumberDto(item, Math.round(Math.random())));
    }
}
