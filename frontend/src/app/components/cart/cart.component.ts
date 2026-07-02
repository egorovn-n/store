import { Component, OnInit } from '@angular/core';
import { ProductAndNumberDto } from '../../dtos/product-and-number.dto';
import { Product } from '../../models/product.model';
import { ProductIdAndNumberDto } from '../../dtos/product-id-and-number.dto';
import { CartItemComponent } from './cart-item.component';

@Component({
    selector: 'cart-component',
    imports: [
        CartItemComponent
    ],
    templateUrl: './cart.component.html'
})
export class CartComponent implements OnInit {
    public itemsWithNumbers: ProductAndNumberDto[] = [];
    public total = 0;

    constructor() {
        this.setFakeItems();
    }

    ngOnInit() {
        this.recalculateTotal();
    }

    public onProductNumberChange(productIdAndNumberDto: ProductIdAndNumberDto) {
        let productIndex = this.itemsWithNumbers.findIndex(
            (item) => item.product.id === productIdAndNumberDto.productId
        );
        if (productIndex < 0) {
            return;
        }
        this.itemsWithNumbers[productIndex].productsNumber = productIdAndNumberDto.productNumber;
        if (productIdAndNumberDto.productNumber === 0) {
            this.itemsWithNumbers = this.itemsWithNumbers.filter(item => item.productsNumber !== 0);
        }
        this.recalculateTotal();
    }

    private recalculateTotal() {
        this.total = this.itemsWithNumbers
            .map(item => item.productsNumber * item.product.price)
            .reduce((acc, sum) => acc + sum, 0)
    }

    private setFakeItems() {
        this.itemsWithNumbers = [
            new ProductAndNumberDto(new Product(0, 'картошка',10), 1),
            new ProductAndNumberDto(new Product(1, 'огурец',20), 2),
            new ProductAndNumberDto(new Product(2, 'колбаса',50), 3)
        ]
    }
}
