import { EventEmitter } from '@angular/core';
import { ProductIdAndNumberDto } from '../../dtos/product-id-and-number.dto';
import { ProductAndNumberDto } from '../../dtos/product-and-number.dto';
import { ProductWithImgSrc } from '../../dtos/product-with-img-src.dto';

export abstract class ProductWithChangeableNumberBaseComponent {
    public productAndNumberDto: ProductAndNumberDto<ProductWithImgSrc> | null = null;
    protected onNumberChange = new EventEmitter<ProductIdAndNumberDto>();
    private canChangeNumber: boolean = false;

    constructor(canChangeNumber: boolean = false) {
        this.canChangeNumber = canChangeNumber;
    }

    public numberIncrement() {
        this.productNumberChange(1);
    }

    public numberDecrement() {
        this.productNumberChange(-1);
    }

    private productNumberChange(numberChange: number): void {
        if (!this.productAndNumberDto || !this.canChangeNumber) {
            return;
        }

        let finalNumber = this.productAndNumberDto.productsNumber + numberChange;
        if (finalNumber < 0) {
            finalNumber = 0;
        }
        this.onNumberChange.emit(new ProductIdAndNumberDto(this.productAndNumberDto.product.id, finalNumber));
    }
}
