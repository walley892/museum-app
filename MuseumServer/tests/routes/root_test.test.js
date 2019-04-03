const rootRoute = require('../.././app/routes/root_route');

let response = rootRoute.getResponse('ok');


test('response is ok', () => {
    expect(response).toEqual({'status' : 'ok'});
});
