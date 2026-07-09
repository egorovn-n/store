import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgOptimizedImage } from '@angular/common';
import { ProductIdAndNumberDto } from '../../dtos/product-id-and-number.dto';
import { ProductAndNumberDto } from '../../dtos/product-and-number.dto';
import { ProductWithImgSrc } from '../../dtos/product-with-img-src.dto';
import { ProductWithChangeableNumberBaseComponent } from '../common/product-with-changeable-number-base.component';

@Component({
    selector: "product",
    templateUrl: "./product.component.html",
    styleUrls: ["./product.component.scss"],
    imports: [
        NgOptimizedImage
    ]
})
export class ProductComponent extends ProductWithChangeableNumberBaseComponent {
    @Input() override productAndNumberDto: ProductAndNumberDto<ProductWithImgSrc> | null = null;
    @Input() override canChangeNumber: boolean = true;
    @Output() override onNumberChange = new EventEmitter<ProductIdAndNumberDto>();

    constructor() {
        super();
    }
}
