import { BehaviorSubject, Observable } from 'rxjs';
import { Injectable } from '@angular/core';

/** Абстрактный класс для облегчения отслеживания того, загрузились данные или нет */
@Injectable()
export class LoadingService {
    /** Флаг, загружаются ли данные сейчас  */
    private _isLoading: BehaviorSubject<boolean> = new BehaviorSubject(false);
    public isLoading$: Observable<boolean> = this._isLoading.asObservable();

    /** Получить текущее значение isLoading */
    public getIsLoadingValue() {
        return this._isLoading.value;
    }

    /** Объявить о начале загрузки */
    public startLoading(): void {
        if (!this.getIsLoadingValue()) {
            this._isLoading.next(true);
        }
    }

    /** Объявить об окончании загрузки */
    public endLoading(): void {
        if (this.getIsLoadingValue()) {
            this._isLoading.next(false);
        }
    }
}
