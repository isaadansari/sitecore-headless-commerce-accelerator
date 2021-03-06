//    Copyright 2020 EPAM Systems, Inc.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

import * as React from 'react';

import { Text, withExperienceEditorChromes } from '@sitecore-jss/sitecore-jss-react';
import { NavigationLink } from 'Foundation/UI/client';
import { NavigationControlProps, NavigationControlState } from './models';

import * as Jss from 'Foundation/ReactJss/client';

import './styles.scss';

class NavigationControl extends Jss.SafePureComponent<NavigationControlProps, NavigationControlState> {
  public safeRender() {
    const { checkoutSteps, backToLink, infoLink } = this.props.fields;
    return (
      <nav className="nav-checkout">
        <ul>
          {checkoutSteps &&
            checkoutSteps.map((checkoutStep, checkoutStepIndex) => {
              const { checkoutStepName } = checkoutStep.fields;
              const stepClassName = this.props.routeFields.id === checkoutStep.fields.id ? 'active' : '';
              return (
                <li key={checkoutStepIndex} className={stepClassName}>
                  {/*<NavigationLink to={checkoutStep.url}>{checkoutStepName.value}</NavigationLink>*/}
                  <span>{checkoutStepName.value}</span>
                </li>
              );
            })}
        </ul>
        <span className="back-to">
          <NavigationLink to={backToLink.value.href}>{backToLink.value.text}</NavigationLink>
        </span>
        <span className="privacy">
          <NavigationLink to={infoLink.value.href}>{infoLink.value.text}</NavigationLink>
        </span>
        <Text field={{ value: 'Back' }} tag="a" className="previous-section" />
      </nav>
    );
  }
}

export const CheckoutNavigation = withExperienceEditorChromes(NavigationControl);
