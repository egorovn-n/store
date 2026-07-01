// Продукт для продажи
export class Product {
    // Идентификатор
    public id: number;

    // Наименование
    public name: string;

    // Цена
    public price: number;

    constructor(id: number, name: string, price: number) {
        this.id = id;
        this.name = name;
        this.price = price;
    }
}
