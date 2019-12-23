import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IAreaOfInterest} from "../../interfaces/IAreaOfInterest";
import {AreaOfInterestService} from "../../services/areaofinterests-service";

export var log = LogManager.getLogger('AreaOfInterests.Create');

@autoinject
export class Create {

  private AreaOfInterest: IAreaOfInterest;

  constructor(
    private router: Router,
    private AreaOfInterestsService: AreaOfInterestService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('AreaOfInterest', this.AreaOfInterest);
    this.AreaOfInterestsService.post(this.AreaOfInterest).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("AreaOfInterestsIndex");
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
