import { Component, OnInit } from '@angular/core';
import { ProductAndNumberDto } from '../../dtos/product-and-number.dto';
import { ProductIdAndNumberDto } from '../../dtos/product-id-and-number.dto';
import { CartItemComponent } from './cart-item.component';
import { ProductWithImgSrc } from '../../dtos/product-with-img-src.dto';
import { CartApiService } from '../../services/apiservices/cart.apiservice';
import { take } from 'rxjs';

@Component({
    selector: 'cart-component',
    imports: [
        CartItemComponent
    ],
    providers: [
        CartApiService
    ],
    templateUrl: './cart.component.html'
})
export class CartComponent implements OnInit {
    public itemsWithNumbers: ProductAndNumberDto<ProductWithImgSrc>[] = [];
    public total = 0;

    constructor(cartApiService: CartApiService) {
        cartApiService.getCartItems().pipe(take(1)).subscribe(items => {
            this.itemsWithNumbers = items;
        })
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
}
