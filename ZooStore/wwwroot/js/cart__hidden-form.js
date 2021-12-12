const cartNumber = document.querySelectorAll('.orderDetails_Quantity');
const hiddenForm = document.querySelectorAll('.orderDetails-hidden_Quantity');

cartNumber.forEach((elem, index) => {
    elem.addEventListener('input', () => {
        hiddenForm[index].value = cartNumber[index].value;
        console.log(hiddenForm[index].value);
        console.log(cartNumber[index].value);
    })
})
