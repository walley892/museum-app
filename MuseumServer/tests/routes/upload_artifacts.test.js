const rootRoute = require('../.././app/routes/upload_artifacts');

let response = rootRoute.getResponse('ok');


test('response is ok', () => {
    expect(response).toEqual({'status' : 'ok'});
});
