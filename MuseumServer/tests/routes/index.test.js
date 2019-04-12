const rootRoute = require('../.././app/routes/index');

let response = rootRoute.getResponse('ok');


test('response is ok', () => {
    expect(response).toEqual({'status' : 'ok'});
});
