import { Component, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IInvestmentInput } from '../../models';

@Component({
  selector: 'app-user-input',
  imports: [FormsModule],
  templateUrl: './user-input.html',
  styleUrls: ['./user-input.scss'],
})
export class UserInput {
  calculate = output<IInvestmentInput>();

  enteredInitialInvestment: number = 0;
  enteredAnnualInvestment: number = 0;
  enteredExpectedReturn: number = 5;
  enteredDuration: number = 10;

  onSubmit() {
    this.calculate.emit({
      initialInvestment: +this.enteredInitialInvestment,
      annualInvestment: +this.enteredAnnualInvestment,
      expectedReturn: +this.enteredExpectedReturn,
      duration: +this.enteredDuration,
    });
  }
}
