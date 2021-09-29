const apiRoutes = {
    api: 'api/electronic-books',
    bookRarity: 'book-rarity',
    books: 'books',
    test: 'test',
}

let rarityCheckboxes = document.getElementsByClassName('book_rarity');
let generCheckboxes = document.getElementsByClassName('book_gener');
let searchBar = document.getElementById('searchBar');
let queryString = '';

searchBar.addEventListener('keyup', (event) => {
    //TODO: Make a regex here
    if (event.keyCode >= 65 &&
        event.keyCode <= 90 &&
        searchBar.value.length > 2) {
        queryString = buildQueryString(searchBar, rarityCheckboxes, generCheckboxes);
        console.log(queryString);
        console.log(event.keyCode);
        fetch(`${apiRoutes.api}/${apiRoutes.test}?${queryString}`);

    } else {
        console.log(event.keyCode)
    }

})

document.getElementById('filtering_searching_managing').addEventListener('change', () => {
    queryString = buildQueryString(searchBar, rarityCheckboxes, generCheckboxes);
    console.log(queryString);
    fetch(`${apiRoutes.api}/${apiRoutes.test}?${queryString}`)
})

function getQueryStringFromCheckboxes(checkboxCollection, checkboxType) {
    var result = '';

    for (let checkbox of checkboxCollection) {
        if (checkbox.checked) {
            result += `${checkboxType}=${checkbox.name.trimEnd()}&`;
        }
    }

    return result;
}

function getQueryFromSearchTerm(searchBar) {
    let result = '';

    result += `${searchBar.getAttribute("name")}=${searchBar.value.toLowerCase()}&`;

    return result;
}

function buildQueryString(searchBar, rarityCheckboxes, generCheckboxes) {
    let result = '';

    result += getQueryFromSearchTerm(searchBar);
    result += getQueryStringFromCheckboxes(rarityCheckboxes, 'rarities');
    result += getQueryStringFromCheckboxes(generCheckboxes, 'geners');

    result = result.substring(0, result.length - 1);
    return result;
}