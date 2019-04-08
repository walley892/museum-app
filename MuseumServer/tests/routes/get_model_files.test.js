const rootRoute = require('../.././app/routes/get_model_files');

let response = rootRoute.getResponse('ok');


test('response is ok', () => {
    expect(response).toEqual({'status' : 'ok'});
});
