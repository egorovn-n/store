/** Статус заказа */
export enum OrderStatusEnum {
    /** Не оплачено */
    NotPaid,

    /** Заказ принят */
    Accepted,

    /** Сборка заказа */
    Assembly,

    /** В пути / Готово к выдаче */
    OnTheWay,

    /** Заказ выполнен */
    Completed,

    /** Заказ отменен */
    Canceled
}
