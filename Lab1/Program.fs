open System

// 14 вариант

// 1 Задание
// Преобразование строки в массив чисел в список
let numbers (input : string) =
    input.Split(' ')
    |> Array.map int
    |> List.ofArray

// Список со значениями -1
let result numbers =
    numbers |> List.map (fun x -> x - 1)


// 2 Задание
let rec countStrings countS =
    printf "Введите строку: "
    let stringInput = Console.ReadLine()
    if stringInput = "" then 
        printfn "Было введено количество строк: %i" countS
    else 
        countStrings (countS + 1)


// 3 Задание
let addElem element list = element :: list

let rec delElem element list =
    if List.isEmpty list then
        []
    elif list.Head = element then
        list.Tail
    else
        list.Head :: delElem element list.Tail

let rec findElem element list =
    match list with
    | [] ->
        printfn "Элемент не найден"
    | head :: tail ->
        if head = element then
            printfn "Элемент \"%s\" найден" element
        else
            findElem element tail

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
    printfn "Введите значения в список (в строку через пробел)"
    let input = Console.ReadLine()
    match input with
    | "" ->
        printfn "Список не введён"
    | _ ->
        let list = numbers input |> result
        printfn "Список значений -1: %A" list


    countStrings 0


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
    findElem find listRemove

    printfn "Введите второй список для сцепки:"
    let list2 = createList()
    let combinedList = combLists listRemove list2
    printfn "Список после сцепки: %A" combinedList

    printf "Введите индекс элемента для поиска: "
    let index = Console.ReadLine() |> int
    getElem index combinedList

    0