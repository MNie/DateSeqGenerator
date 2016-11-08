namespace DateSeqGenerator.Tests
open DateSeqGenerator
open System
open FsCheck
open Xunit

type ``DateSeqGenerator tests``() = 
    [<Fact>]
    let ``first element should be equal to start date``() =
        let test(startDate: DateTime, endDate: DateTime, step: int) =
            let result = Generator.generateInRangeWithSFormatting(startDate, endDate, step) |> Seq.head
            (result = startDate.ToString("s"))
                .When(startDate < endDate)
                .Label(String.Format("first element of a sequence {0} is not equal to a start date {1}, endDate: {2}, step: {3}", result, startDate.ToString("s"), endDate.ToString("s"), step))
        Check.QuickThrowOnFailure test

