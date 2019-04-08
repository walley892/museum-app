module.exports = {
    saveModel : saveModel,
    saveTexture : saveTexture
};


function saveModel(pid, callback) {
    pullPlaylist(pid, function(json) {
        var filePath = 'models/' + pid +'/playlist.json';
        ensureDirectoryExistence(filePath);
        fs.writeFileSync(filePath, JSON.stringify(json));
        callback();
    });
}

function saveTexture(pid, callback) {
    pullPlaylist(pid, function(json) {
        var filePath = 'textures/' + pid +'/playlist.json';
        ensureDirectoryExistence(filePath);
        fs.writeFileSync(filePath, JSON.stringify(json));
        callback();
    });
}


function ensureDirectoryExistence(filePath) {
    var dirname = path.dirname(filePath);
    if (fs.existsSync(dirname)) {
        return true;
    }
    ensureDirectoryExistence(dirname);
    fs.mkdirSync(dirname);
}