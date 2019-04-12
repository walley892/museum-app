var path = require('path');
var fs = require('fs');

module.exports = {
    ensureDirectoryExistence: ensureDirectoryExistence
};


function ensureDirectoryExistence(filePath) {
    var dirname = path.dirname(filePath);
    if (fs.existsSync(dirname)) {
        return true;
    }
    ensureDirectoryExistence(dirname);
    fs.mkdirSync(dirname);
}