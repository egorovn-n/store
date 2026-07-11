import { ElementRef } from '@angular/core';

/** Класс-помощник для работы с HtmlElement */
export abstract class HtmlElementsHelper {
    /**
     * Обновить атрибут disabled у всех input
     * @param isDisabled true - добавить disabled, false - убрать disabled
     * @param element элемент, внутри которого нужно найти тег. Если undefined, то метод не сработает
     */
    public static setInputDisabledAttribute(isDisabled: boolean, element: ElementRef | undefined): void {
        this.setDisabledAttributeForTag(isDisabled, 'input', element);
    }

    /**
     * Обновить атрибут disabled у всех button
     * @param isDisabled true - добавить disabled, false - убрать disabled
     * @param element элемент, внутри которого нужно найти тег. Если undefined, то метод не сработает
     */
    public static setButtonDisabledAttribute(isDisabled: boolean, element: ElementRef | undefined): void {
        this.setDisabledAttributeForTag(isDisabled, 'button', element);
    }

    /**
     * Обновить атрибут disabled у всех элементов с заданным тегом
     * @param isDisabled true - добавить disabled, false - убрать disabled
     * @param tag тег элемента
     * @param element элемент, внутри которого нужно найти тег. Если undefined, то метод не сработает
     */
    private static setDisabledAttributeForTag(isDisabled: boolean, tag: string, element: ElementRef | undefined): void {
        if (!element) {
            return;
        }

        const tagCollection = element.nativeElement.getElementsByTagName(tag);

        if (!tagCollection) {
            return;
        }

        for (const tag of tagCollection) {
            if (isDisabled) {
                tag.setAttribute('disabled', 'true');
            } else {
                tag.removeAttribute('disabled');
            }
        }
    }
}
