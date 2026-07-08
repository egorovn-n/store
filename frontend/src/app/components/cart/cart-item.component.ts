import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProductIdAndNumberDto } from '../../dtos/product-id-and-number.dto';
import { NgOptimizedImage } from '@angular/common';
import { ProductWithChangeableNumberBaseComponent } from '../common/product-with-changeable-number-base.component';
import { ProductAndNumberDto } from '../../dtos/product-and-number.dto';
import { ProductWithImgSrc } from '../../dtos/product-with-img-src.dto';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
    selector: 'cart-item',
    templateUrl: './cart-item.component.html',
    imports: [
        NgOptimizedImage
    ]
})
export class CartItemComponent extends ProductWithChangeableNumberBaseComponent implements OnInit {
    @Input() override productAndNumberDto: ProductAndNumberDto<ProductWithImgSrc> | null = null;
    @Output() override onNumberChange = new EventEmitter<ProductIdAndNumberDto>();
    public sum: number = 0;

    constructor() {
        super(true);
        this.onNumberChange.pipe(takeUntilDestroyed()).subscribe((value: ProductIdAndNumberDto) => {
            if (!value || !this.productAndNumberDto) {
                return;
            }
            this.sum = this.productAndNumberDto.product.price * value.productNumber;
        })
    }

    ngOnInit() {
        if (!this.productAndNumberDto) {
            return;
        }

        this.sum = this.productAndNumberDto.product.price * this.productAndNumberDto.productsNumber;
    }
}
