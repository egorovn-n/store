/** Dto для картинок. */
export class ImageDto {
    /** Гуид картинки */
    public guid: string;

    /** Base64 строка картинки. */
    public base64String: string;

    constructor(guid: string, base64String: string) {
        this.guid = guid;
        this.base64String = base64String;
    }
}
