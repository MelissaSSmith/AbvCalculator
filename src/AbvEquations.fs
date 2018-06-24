module AbvEquations

let Abv og fg : decimal = (og - fg) * 131.25m

let AlternateAbv og fg : decimal = (76.08m * (og - fg) / (1.775m - og)) * (fg / 0.794m)

let CalFromAlcohol og fg : decimal = 1881.22m * fg * (og - fg)/(1.775m - og)

let CalFromCarbs og fg : decimal = 3550.0m * fg * ((0.1808m * og) + (0.819m * fg) - 1.0004m)

let TotalCal og fg = CalFromAlcohol og fg + CalFromCarbs og fg