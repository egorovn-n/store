import { Product } from '../models/product.model';

export class ProductWithImgSrc extends Product {
    public imgSrc: string;

    constructor(id: number, name: string, price: number, imgSrc: string) {
        super(id, name, price);
        this.imgSrc = imgSrc;
    }
}
