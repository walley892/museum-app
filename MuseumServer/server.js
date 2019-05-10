const app = require('./app')

const port = process.env.PORT || 80;

app.listen(port, function() {
    console.log('Live on ' + port);
});
