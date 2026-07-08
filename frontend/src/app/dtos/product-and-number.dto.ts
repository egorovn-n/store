import { Product } from '../models/product.model';

export class ProductAndNumberDto<T extends Product> {
    public product: T;
    public productsNumber: number;

    constructor(product: T, productsNumber: number) {
        this.product = product;
        this.productsNumber = productsNumber;
    }
}
