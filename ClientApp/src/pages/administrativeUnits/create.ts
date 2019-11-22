import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IAdministrativeUnit} from "../../interfaces/IAdministrativeUnit";
import {AdministrativeUnitService} from "../../services/administrativeunit-service";

export var log = LogManager.getLogger('AdministrativeUnits.Create');

@autoinject
export class Create {

  private AdministrativeUnit: IAdministrativeUnit;

  constructor(
    private router: Router,
    private AdministrativeUnitsService: AdministrativeUnitService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('AdministrativeUnit', this.AdministrativeUnit);
    this.AdministrativeUnitsService.post(this.AdministrativeUnit).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("AdministrativeUnitsIndex");
        } else {
          log.error('Error in response!', response);
        }
      }
    );
  }

  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');
  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
