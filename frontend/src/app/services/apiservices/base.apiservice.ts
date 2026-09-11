import { HttpParams } from '@angular/common/http';

/** Базовый апи сервис с некоторыми методами. */
export abstract class BaseApiService {
    /**
     * Добавить в HttpParams поля из объекта для queryParam get-запроса.
     * @param params HttpParams, который нужно дополнить.
     * @param obj Объект, из которого берутся поля.
     * @protected
     */
    protected addObjectPropertiesToHttpParams(params: HttpParams, obj: any): HttpParams {
        Object.keys(obj).forEach(key => {
            const value = obj[key];
            if (value !== undefined && value !== null) {
                params = params = params.set(key, value.toString());
            }
        });

        return params;
    }

    /**
     * Получить HttpParams из массива для queryParam get-запроса.
     * @param params HttpParams, который нужно дополнить.
     * @param parameterName Имя параметра, которое будет указано в queryParams.
     * @param arr Массив, элементы которого нужно поместить в queryParams.
     * @protected
     */
    protected addArrayElementsToHttpParams(params: HttpParams, parameterName: string, arr: any[]): HttpParams {
        if (!arr || arr.length < 1) {
            return params;
        }

        arr.forEach(productId => {
            params = params.append(parameterName, productId);
        });

        return params;
    }
}
