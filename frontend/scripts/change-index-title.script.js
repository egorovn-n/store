const fs = require('fs');
const path = require('path');

const errorText = "Нужно ввести одну из опций: --prod или --dev для использования environment.ts продуктового" +
    " режима или для разработки соответственно";
if (process.argv.length !== 3) {
    throw(new Error(errorText));
}

let environmentFileName = '';

switch (process.argv[2]) {
    case "--prod": {
        environmentFileName = 'environment.ts';
        break;
    }
    case "--dev": {
        environmentFileName = 'environment.development.ts';
        break;
    }
    default: {
        throw (new Error(errorText));
    }
}

// Читаем environment
const environmentPath = path.join(__dirname, '../src/environments', environmentFileName);
const envContent = fs.readFileSync(environmentPath, 'utf8');

// Извлекаем appTitle (упрощенный парсинг)
const appTitleMatch = envContent.match(/appTitle:\s*['"]([^'"]+)['"]/);
const appTitle = appTitleMatch ? appTitleMatch[1] : 'Default App Title';

// Читаем index.html
const indexPath = path.join(__dirname, '../src/index.template.html');
let indexContent = fs.readFileSync(indexPath, 'utf8');

// Заменяем
indexContent = indexContent.replace(/__APP_TITLE__/g, appTitle);

// Сохраняем во временный файл или напрямую
const outputPath = path.join(__dirname, '../src/index.html');
fs.writeFileSync(outputPath, indexContent);
console.log(`✅ Index generated with title: ${appTitle}`);
