import { ProductWithImgSrc } from '../dtos/product-with-img-src.dto';
import { OrderStatusEnum } from '../enums/order-status.enum';
import { OrderTypeEnum } from '../enums/order-type.enum';
import { ProductAndNumberDto } from '../dtos/product-and-number.dto';

/** Модель заказа */
export class OrderModel {
    /** Идентификатор */
    public id: number = 0;

    /** Список продуктов в заказе */
    public products: ProductAndNumberDto<ProductWithImgSrc>[] = [];

    /** Статус заказа */
    public orderStatus: OrderStatusEnum = OrderStatusEnum.NotPaid;

    /** Тип заказа */
    public orderType: OrderTypeEnum = OrderTypeEnum.None;

    /** Итоговая сумма заказа */
    public total: number = 0;

    /** Дата и время заказа */
    public orderDateTime: Date | null = null;
}
