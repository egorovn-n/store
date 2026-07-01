import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgOptimizedImage } from '@angular/common';
import { ProductIdAndNumberDto } from '../../dtos/product-id-and-number.dto';

@Component({
    selector: "product",
    templateUrl: "./product.component.html",
    styleUrls: ["./product.component.scss"],
    imports: [
        NgOptimizedImage
    ]
})
export class ProductComponent {
    @Input() productId: number = -1;
    @Input() productName: string = 'Пусто';
    @Input() price: number = NaN;
    @Input() imgSrc: string = 'favicon.ico';
    @Input() productsNumber: number = 0;
    @Output() onNumberChange = new EventEmitter<ProductIdAndNumberDto>();

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
