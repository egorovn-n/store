import { OrderStatusEnum } from '../enums/order-status.enum';
import { OrderTypeEnum } from '../enums/order-type.enum';

/** Помощник по статусам заказа */
export abstract class OrderHelper {
    public static translateOrderStatus(status: OrderStatusEnum, orderType: OrderTypeEnum): string {
        switch (orderType) {
            case OrderTypeEnum.Pickup: {
                return OrderHelper.translatePickupStatus(status);
            }
            case OrderTypeEnum.Delivery: {
                return OrderHelper.translateDeliveryStatus(status)
            }
            default: {
                return 'Неизвестный тип заказа';
            }
        }
    }

    /** Получить статус, изображенный квадратами */
    public static getVisualStatus(status: OrderStatusEnum): string {
        switch (status) {
            case OrderStatusEnum.Accepted: {
                return '□□□';
            }
            case OrderStatusEnum.Assembly: {
                return '■□□';
            }
            case OrderStatusEnum.OnTheWay: {
                return '■■□';
            }
            case OrderStatusEnum.Completed: {
                return '✓';
            }
            case OrderStatusEnum.Canceled: {
                return '✘';
            }
            default: {
                return '';
            }
        }
    }

    /** Перевести тип заказа */
    public static translateOrderType(orderType: OrderTypeEnum): string {
        switch (orderType) {
            case OrderTypeEnum.None: {
                return 'Не выбран';
            }
            case OrderTypeEnum.Pickup: {
                return 'Самовывоз';
            }
            case OrderTypeEnum.Delivery: {
                return 'Доставка';
            }
            default: {
                return '';
            }
        }
    }

    /** Перевести статус доставки */
    private static translateDeliveryStatus(status: OrderStatusEnum): string {
        switch (status) {
            case OrderStatusEnum.NotPaid: {
                return 'Не оплачен';
            }
            case OrderStatusEnum.WaitingForPayment: {
                return 'Ожидание оплаты';
            }
            case OrderStatusEnum.Accepted: {
                return 'Заказ принят';
            }
            case OrderStatusEnum.Assembly: {
                return 'Сборка';
            }
            case OrderStatusEnum.OnTheWay: {
                return 'В пути';
            }
            case OrderStatusEnum.Completed: {
                return 'Заказ завершён';
            }
            case OrderStatusEnum.Canceled: {
                return 'Заказ отменён';
            }
            default: {
                return 'Ошибка в определении статуса';
            }
        }
    }

    /** Перевести статус самовывоза */
    private static translatePickupStatus(status: OrderStatusEnum): string {
        if (status === OrderStatusEnum.OnTheWay) {
            return 'Можно забирать';
        }

        return OrderHelper.translateDeliveryStatus(status);
    }
}
