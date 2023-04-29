function show(target)
{
	var input = document.getElementById('Password');
	var inputTwo = document.getElementById('RepPassword');

	if (input.getAttribute('type') == 'password' && inputTwo.getAttribute('type') == 'password') {
		target.classList.add('view');
	
		target.innerHTML = "Скрыть пароль";
		input.setAttribute('type', 'text');
		inputTwo.setAttribute('type', 'text');
	} else {
		target.classList.remove('view');
		target.innerHTML = "Показать пароль"
		input.setAttribute('type', 'password');
		inputTwo.setAttribute('type', 'password');
	}
}

