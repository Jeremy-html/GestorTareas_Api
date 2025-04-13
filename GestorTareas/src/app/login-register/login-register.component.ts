import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login-register',
  templateUrl: './login-register.component.html',  // Asegúrate de que la ruta sea correcta
  styleUrls: ['./login-register.component.scss']
})

export  class LoginRegisterComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      pass: ['', [Validators.required, Validators.minLength(6)]]
    });
  }


  isInvalid(controlName: string): boolean {
    const control = this.loginForm.get(controlName);
    return !!(control && control.invalid && (control.dirty || control.touched));
  }


  onSubmit(): void {
    if (this.loginForm.valid) {
      console.log('Form submitted', this.loginForm.value);

            // Redirigir al componente de tareas después de un login exitoso
            this.router.navigate(['/taskplanner']);
    }
  }
}

