const req = {                                           // объявили переменную req
    url: "https://send-request.me/api/auth/authorize",  // на этот URL отправляем запрос
    method: "POST",                                     // Определяем метод
    header: {
        "Content-Type": "application/json",             // Определяем "Content-Type" нашего request body
    },
    body: {
        mode: "raw",                                    // определяем формат request body
        raw: {                                          // в ключ raw передаем JSON, который мы отправляли в С-01
            "login": "Abc",
            "password": "qwerty12345",
            "timeout": 3,                               // время жизни токена
        },
    },
};

pm.sendRequest(req, function (err, response) {          // передать переменную req первым аргументом
    pm.variables.set("token", response.json().token)    // сохранить в лок. переменную актуальный токен
});

setTimeout(function(){}, 5000);                         // ставим ожидание в 5 секунд, что-бы токен успел истечь