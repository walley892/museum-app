const rootRoute = require('../.././app/routes/get_model_info');

let response = rootRoute.getResponse('ok');


test('response is ok', () => {
    expect(response).toEqual({'status' : 'ok'});
});
