import {Component, EventEmitter, Input, OnChanges, Output} from '@angular/core';
import { ProductIdAndNumberDto } from '../../dtos/product-id-and-number.dto';
import { NgOptimizedImage } from '@angular/common';

@Component({
    selector: 'cart-item',
    templateUrl: './cart-item.component.html',
    imports: [
        NgOptimizedImage
    ]
})
export class CartItemComponent implements OnChanges {
    @Input() productId: number = -1;
    @Input() productName: string = 'Пусто';
    @Input() price: number = NaN;
    @Input() imgSrc: string = 'favicon.ico';
    @Input() productsNumber: number = 0;
    @Output() onNumberChange = new EventEmitter<ProductIdAndNumberDto>();
    public sum: number = 0;

    ngOnChanges() {
        this.sum = this.price * this.productsNumber;
    }

    public numberIncrement() {
        this.productNumberChange(1);
    }

    public numberDecrement() {
        this.productNumberChange(-1);
    }

    private productNumberChange(numberChange: number): void {
        let finalNumber = this.productsNumber + numberChange;
        if (finalNumber < 0) {
            finalNumber = 0;
        }
        this.onNumberChange.emit(new ProductIdAndNumberDto(this.productId, finalNumber));
    }
}
