export class ProductIdAndNumberDto {
    public productId: number;
    public productNumber: number;
    constructor(productId: number, productNumber: number) {
        this.productId = productId;
        this.productNumber = productNumber;
    }
}
