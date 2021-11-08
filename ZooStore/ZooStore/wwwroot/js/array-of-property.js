const blockProperty = document.querySelector('.property-array');

function getProperties() {
    return document.querySelectorAll('.property-element');
}

function addProp(){
    let div = document.createElement('div');
    div.classList.add('property-element');
    let index = getProperties().length;
    div.innerHTML = 
    `<label for="Properties_${index}__Key">Key ${index}</label>
    <input class="form-control" type="text" data-val="true" data-val-required="The Key field is required." id="Properties_${index}__Key" name="Properties[${index}].Key" value="">
    <label for="Properties_${index}__Value">Value ${index}</label>
    <input class="form-control" type="text" data-val="true" data-val-required="The Value field is required." id="Properties_${index}__Value" name="Properties[${index}].Value" value="">`;
    blockProperty.append(div);

}
function removeProp(){
    blockProperty.removeChild(blockProperty.lastChild);
}