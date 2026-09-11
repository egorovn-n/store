/** Dto для файлов. */
export class FileDto {
    /** Гуид файла */
    public guid: string;

    /** Байты файла. */
    public fileBytes: Blob;

    constructor(guid: string, fileBytes: Blob) {
        this.guid = guid;
        this.fileBytes = fileBytes;
    }
}
