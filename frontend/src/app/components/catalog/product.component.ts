import { Component, Input, OnInit } from '@angular/core';
import { NgOptimizedImage } from '@angular/common';
import { ProductFullDto } from '../../dtos/product-full.dto';
import { ProductImagesHelper } from '../../helpers/product-images.helper';
import { ImageVariantsEnum } from '../../enums/image-variants.enum';

/** Компонент карты товара. */
@Component({
    selector: "product",
    templateUrl: "./product.component.html",
    styleUrls: ["./product.component.scss"],
    imports: [
        NgOptimizedImage
    ]
})
export class ProductComponent implements OnInit {
    @Input() product: ProductFullDto | null = null;
    @Input() isFirst: boolean = false;
    protected imageUrls: string[] = [];

    ngOnInit(): void {
        if (!this.product){
            return;
        }

        this.imageUrls = this.product.imageGuids
            .map(ig => ProductImagesHelper.getImageUrlFromGuid(ig, ImageVariantsEnum.Thumb200));
    }

    /** Обработчик ошибки загрузки картинки с сервера. */
    public onImageError(event: Event) {
        const img = event.target as HTMLImageElement;
        img.src = ProductImagesHelper.Thumb200ImagePath;
    }
}
