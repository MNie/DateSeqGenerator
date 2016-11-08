namespace DateSeqGenerator
module Generator =
    open System

    let generateInRange(startDate: DateTime, endDate: DateTime, step: int, format: string) = 
        let rec getRecursiveDates(date: DateTime) =
            if date < endDate then seq { 
                yield date.ToString(format) 
                yield! getRecursiveDates(date.AddDays(step |> float)) }
            else seq { yield date.ToString(format) }
        getRecursiveDates(startDate)

    let generateInRangeWithSFormatting(startDate: DateTime, endDate: DateTime, step: int) = 
        generateInRange(startDate, endDate, step, "s")

    let generateInRangeWithSingleStep(startDate: DateTime, endDate: DateTime, format: string) =
        generateInRange(startDate, endDate, 1, format)

    let generateInRangeWithDefaultStepAndFormat(startDate: DateTime, endDate: DateTime) =
        generateInRange(startDate, endDate, 1, "s")