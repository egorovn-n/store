/** Dto товара со всей информацией. */
export class ProductFullDto {
    /** Идентификатор. */
    public id: number;

    /** Наименование. */
    public name: string;

    /** Гуиды картинок товара. */
    public imageGuids: string[];

    /** Цена. */
    public price: number;

    constructor(id: number, name: string, imageGuids: string[], price: number) {
        this.id = id;
        this.name = name;
        this.imageGuids = imageGuids;
        this.price = price;
    }
}
