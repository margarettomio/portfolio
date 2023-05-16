pm.test("Status code is 202", function () {
    pm.response.to.have.status(202);
});

pm.test("Response time is less than 500ms", function () {
    pm.expect(pm.response.responseTime).to.be.below(500);
});

pm.test("Headers is valid", function () {
    pm.expect(pm.response.headers.get('Content-Type')).to.eql('application/json');
    pm.expect(pm.response.headers.get('Connection')).to.eql('keep-alive')
});

//to.not.include - означает, "не должен содержать" - не должен содержать null в ответе

pm.test("Response body !== null", function(){
    pm.expect(pm.response.json()).to.not.include([null]);
});

//Что-бы очистить наши переменные коллекций
pm.collectionVariables.clear();