open System

// 14 вариант

// 1 Задание
printfn "Введите значения в список (в строку через пробел)"
let input = Console.ReadLine()

// Преобразование строки в массив чисел в список
let numbers =
    input.Split(' ')
    |> Array.map int
    |> List.ofArray

// Список со значениями -1
let result =
    numbers |> List.map (fun x -> x - 1)

printfn "Список значений -1: %A" result

// 2 Задание
let rec countStrings n =
    printf "Введите строку: "
    let stroka = Console.ReadLine()
    if stroka = "" then printfn "Было введено количество строк: %i" n
    else countStrings(n + 1)

//[<EntryPoint>]
//let main argv =
//    countStrings 0
    
//    0

// 3 Задание
let addElem element list = element :: list

let rec delElem element list =
    if List.isEmpty list then
        []
    elif list.Head = element then
        list.Tail
    else
        list.Head :: delElem element list.Tail

let findElem element list = List.contains element list

let combLists list1 list2 = list1 @ list2

let getElem index list =
    if index < 0 || index >= List.length list then
        printfn "Элемент с индексом %d не найден" index
    else
        let elem = List.item index list
        printfn "Элемент по индексу %d: \"%s\"" index elem

let rec createList () =
    let input = Console.ReadLine()
    if input = "" then
        []
    else
        input :: createList()

[<EntryPoint>]
let main argv =
    printfn "Введите элементы списка:"
    let myList = createList()
    printfn "Изначальный список: %A" myList

    printf "Введите элемент для добавления в начало: "
    let elemAdd = Console.ReadLine()
    let listAdd = addElem elemAdd myList
    printfn "Список после добавления в начало: %A" listAdd

    printf "Введите значение элемента для удаления: "
    let elemRemove = Console.ReadLine()
    let listRemove = delElem elemRemove listAdd
    printfn "Список после удаления: %A" listRemove

    printf "Введите элемент для поиска: "
    let find = Console.ReadLine()
    let exists = findElem find listRemove
    if exists then
        printfn "Элемент \"%s\" найден" find
    else
        printfn "Элемент не найден"

    printfn "Введите второй список для сцепки:"
    let list2 = createList()
    let combinedList = combLists listRemove list2
    printfn "Список после сцепки: %A" combinedList

    printf "Введите индекс элемента для поиска: "
    let index = Console.ReadLine() |> int
    getElem index combinedList

    0