import { environment } from '@environment/environment';
import { ImageVariantsEnum } from '../enums/image-variants.enum';

/** Класс-помощник для работы с картинками. */
export abstract class ProductImagesHelper {
    public static readonly Thumb200ImagePath = 'product-placeholder-image/thumb200.webp';
    /** Получить url картинки по guid. */
    public static getImageUrlFromGuid(guid: string, imageVariant: ImageVariantsEnum): string {
        return `${environment.apiUrl}api/Images/GetImage/${guid}?imageVariant=${imageVariant}`;
    }
}
