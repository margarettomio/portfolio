pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});

pm.test("Response time is less than 500ms", function () {
    pm.expect(pm.response.responseTime).to.be.below(500);
});

pm.test("Headers is valid", function () {
    pm.expect(pm.response.headers.get('Content-Type')).to.eql('application/json');
    pm.expect(pm.response.headers.get('Connection')).to.eql('keep-alive')
});

pm.test("Verify company status", function(){
    for(let company of pm.response.json().data){
        pm.expect(company.company_status).to.be.eql("CLOSED");
    }
});


let schema = JSON.parse(pm.environment.get("CompanyList"));

pm.test('Schema is valid', function () {
	pm.response.to.have.jsonSchema(schema);
});