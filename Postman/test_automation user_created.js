pm.collectionVariables.set("user_id", pm.response.json().user_id);
pm.collectionVariables.set("first_name", pm.response.json().first_name);
pm.collectionVariables.set("last_name", pm.response.json().last_name);
pm.collectionVariables.set("company_id", pm.response.json().company_id);

pm.test("Status code is 201", function () {
    pm.response.to.have.status(201);
});

pm.test("Response time is less than 500ms", function () {
    pm.expect(pm.response.responseTime).to.be.below(500);
});

pm.test("Headers is valid", function () {
    pm.expect(pm.response.headers.get('Content-Type')).to.eql('application/json');
    pm.expect(pm.response.headers.get('Connection')).to.eql('keep-alive')
});

let schema = {
  "type": "object",
  "properties": {
    "first_name": {
      "type": "string",
      "enum": ["Pifagor"]
    },
    "last_name": {
      "type": "string",
      "enum": ["Samosskiy"]
    },
    "company_id": {
      "type": "integer",
      "enum": [ 3 ]
    },
    "user_id": {
      "type": "integer"
    }
  },
  "required": [
    "last_name",
    "user_id"
  ]
}

pm.test('Schema is valid', function() {
    pm.response.to.have.jsonSchema(schema);
});

postman.setNextRequest("34IssuesGetUserById")