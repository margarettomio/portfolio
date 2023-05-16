pm.test("Status code is 403", function () {
    pm.response.to.have.status(403);
});

pm.test("Response time is less than 500ms", function () {
    pm.expect(pm.response.responseTime).to.be.below(500);
});

pm.test("Headers is valid", function () {
    pm.expect(pm.response.headers.get('Content-Type')).to.eql('application/json');
    pm.expect(pm.response.headers.get('Connection')).to.eql('keep-alive')
});


let DataJson = pm.response.json().detail

pm.test("Verify reason", function () {
    pm.expect(DataJson.reason).to.eql('Token is expired. Please login and try again')
});