/** Помощник по тексту */
export abstract class TextHelper {
    /** Сделать первую букву текста заглавной */
    public static capitalizeFirstLetter(text: string) {
        if (text.length === 0) {
            return text;
        }

        return text.charAt(0).toUpperCase() + text.slice(1);
    }
}
