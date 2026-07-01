import { Product } from '../models/product.model';

export class ProductAndNumberDto {
    public product: Product;
    public productsNumber: number;
    constructor(product: Product, productsNumber: number) {
        this.product = product;
        this.productsNumber = productsNumber;
    }
}
