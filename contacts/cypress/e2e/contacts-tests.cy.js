describe('template spec', () => {
  beforeEach(() => {
    cy.visit("http://localhost:5173/");
  })

  it('Add a new contact', () => {
    // Перевіряємо, що список контактів порожній
    cy.get("ul li").should('have.length', 0);

    // Додаємо новий контакт
    cy.get('input[placeholder="Ім\'я"]').type('Stepan');
    cy.get('input[placeholder="Телефон"]').type('0998763959');
    cy.get('button').contains('Додати').click();

    // Перевіряємо, що контакт був доданим
    cy.get("ul li").should('have.length', 1);
    cy.contains("Stepan - 0998763959").should('exist');
  });

  it('Add a new contact with empty input', () => {
    // Перевіряємо, що список контактів порожній
    cy.get("ul li").should('have.length', 0);

    // Додаємо новий контакт, попередньо не ввівши дані
    cy.get('button').contains('Додати').click();

    // Перевіряємо, що контакт не був доданий
    cy.get("ul li").should('have.length', 0);
  });

  it('Edit an existing contact', () => {
    // Додаємо новий контакт
    cy.get('input[placeholder="Ім\'я"]').type('Step');
    cy.get('input[placeholder="Телефон"]').type('0990000000');
    cy.get('button').contains('Додати').click();

    // Шукаємо контакт і натискаємо його кнопку "Видалити"
    cy.contains("Step - 0990000000").parent().within(() => {
      cy.get('button').contains('Редагувати').click();
    });

    // Редагуємо контакт і зберігаємо зміну
    cy.get('input[placeholder="Телефон"]').clear().type('0997654835');
    cy.get('input[placeholder="Ім\'я"]').clear().type('Stepan');
    cy.get('.form-container button').contains('Редагувати').click();
    
    // Перевіряємо, що старий контакт зник
    cy.contains("Step - 0990000000").should('not.exist');

    // Перевіряємо, що з'явився новий контакт
    cy.contains("Stepan - 0997654835").should('exist');
  });

  it('Delete an existing contact', () => {
    // Перевіряємо, що список контактів порожній
    cy.get("ul li").should('have.length', 0);
    
    // Додаємо новий контакт
    cy.get('input[placeholder="Ім\'я"]').type('Stepan');
    cy.get('input[placeholder="Телефон"]').type('0998763959');
    cy.get('button').contains('Додати').click();

    // Перевіряємо, що контакт був доданий
    cy.get("ul li").should('have.length', 1);
    cy.contains("Stepan - 0998763959").should('exist');

    // Шукаємо контакт і натискаємо його кнопку "Видалити"
    cy.contains("Stepan - 0998763959").parent().within(() => {
      cy.get('button').contains('Видалити').click();
    });
  
    // Перевіряємо, що контакт був видалений
    cy.get("ul li").should('have.length', 0);
    cy.contains("Stepan - 0998763959").should('not.exist');
  });

  it('Sort contacts by name', () => {
    // Додаємо новий контакт
    cy.get('input[placeholder="Ім\'я"]').type('Barbara');
    cy.get('input[placeholder="Телефон"]').type('0997863876');
    cy.get('button').contains('Додати').click();

    // Додаємо новий контакт
    cy.get('input[placeholder="Ім\'я"]').type('Viktor');
    cy.get('input[placeholder="Телефон"]').type('0991234567');
    cy.get('button').contains('Додати').click();

    // Додаємо новий контакт
    cy.get('input[placeholder="Ім\'я"]').type('Alina');
    cy.get('input[placeholder="Телефон"]').type('0999876543');
    cy.get('button').contains('Додати').click();

    // Сортуємо за ім'ям
    cy.get('button').contains('Сортувати за іменем').click();

    // Перевіряємо сортування
    cy.get("ul li").first().within(() => {
      cy.contains("Alina").should('exist');
    });

    // Перевіряємо сортування
    cy.get("ul li").last().within(() => {
      cy.contains("Viktor").should('exist');
    });
  });


  it('Sort contacts by phone number', () => {
    // Додаємо новий контакт
    cy.get('input[placeholder="Ім\'я"]').type('Barbara');
    cy.get('input[placeholder="Телефон"]').type('0997863876');
    cy.get('button').contains('Додати').click();

    // Додаємо новий контакт
    cy.get('input[placeholder="Ім\'я"]').type('Viktor');
    cy.get('input[placeholder="Телефон"]').type('0991234567');
    cy.get('button').contains('Додати').click();

    // Додаємо новий контакт
    cy.get('input[placeholder="Ім\'я"]').type('Alina');
    cy.get('input[placeholder="Телефон"]').type('0999876543');
    cy.get('button').contains('Додати').click();

    // Сортуємо за ім'ям
    cy.get('button').contains('Сортувати за телефоном').click();

    // Перевіряємо сортування
    cy.get("ul li").first().within(() => {
      cy.contains("Viktor").should('exist');
    });

    // Перевіряємо сортування
    cy.get("ul li").last().within(() => {
      cy.contains("Alina").should('exist');
    });
  });
})